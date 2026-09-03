using System.Runtime.ExceptionServices;
using System.Windows.Threading;
namespace DevLab.Wpf.Tests;
// WPF objects must be created and used on the same STA thread. Capture failures
// and rethrow on the test thread so the runner records assertion failures normally.
internal static class Sta
{
    // Invoke at a lower priority than DataBind, Render, and Loaded. Because this
    // call runs on the dispatcher thread at a non-Send priority, WPF pumps its
    // queue until the marker runs. This is a queue barrier, not a timed sleep.
    public static void DrainDispatcher()
        => Dispatcher.CurrentDispatcher.Invoke(() => { }, DispatcherPriority.ApplicationIdle);

    public static void Run(Action action)
    {
        Exception? failure = null;
        var thread = new Thread(() =>
        {
            try { action(); }
            catch (Exception ex) { failure = ex; }
            finally { Dispatcher.CurrentDispatcher.InvokeShutdown(); }
        }) { IsBackground = true };
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        if (!thread.Join(TimeSpan.FromSeconds(15)))
            throw new TimeoutException("The STA example did not finish within 15 seconds.");
        if (failure is not null) ExceptionDispatchInfo.Capture(failure).Throw();
    }
}
