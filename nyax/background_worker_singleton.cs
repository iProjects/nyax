using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace nyax
{

    public sealed class background_worker_singleton
    {
        // Because the _instance member is made private, the only way to get the single
        // instance is via the static Instance property below. This can also be similarly
        // achieved with a GetInstance() method instead of the property.
        private static background_worker_singleton singleInstance;
        //flag to check if background worker is running
        private bool _is_backgroud_worker_running = false;
        public bool get_is_backgroud_worker_running()
        {
            return _is_backgroud_worker_running;
        }
        public void set_is_backgroud_worker_running(bool is_backgroud_worker_running)
        {
            _is_backgroud_worker_running = is_backgroud_worker_running;
        }
        public static background_worker_singleton getInstance()
        {
            // The first call will create the one and only instance.
            if (singleInstance == null)
                singleInstance = new background_worker_singleton();
            // Every call afterwards will return the single instance created above.
            return singleInstance;
        }

        /* to use a BackgroundWorker object to perform time-intensive operations in a background thread.
       You need to:
       1. Define a worker method that does the time-intensive work and call it from an event handler for the DoWork
       event of a BackgroundWorker.
       2. Start the execution with RunWorkerAsync. Any argument required by the worker method attached to DoWork
       can be passed in via the DoWorkEventArgs parameter to RunWorkerAsync.
       In addition to the DoWork event the BackgroundWorker class also defines two events that should be used for
       interacting with the user interface. These are optional.
       The RunWorkerCompleted event is triggered when the DoWork handlers have completed.
       The ProgressChanged event is triggered when the ReportProgress method is called. */
        private static BackgroundWorker bgWorker;

        private background_worker_singleton()
        {

            //This allows the BackgroundWorker to be cancelled in between tasks
            bgWorker.WorkerSupportsCancellation = true;
            //This allows the worker to report progress between completion of tasks...
            //this must also be used in conjunction with the ProgressChanged event
            bgWorker.WorkerReportsProgress = true;

            //this assigns event handlers for the backgroundWorker
            //bgWorker.DoWork += bgWorker_DoWork;
            //bgWorker.RunWorkerCompleted += bgWorker_WorkComplete;
            /* When you wish to have something occur when a change in progress
                occurs, (like the completion of a specific task) the "ProgressChanged"
                event handler is used. Note that ProgressChanged events may be invoked
                by calls to bgWorker.ReportProgress(...) only if bgWorker.WorkerReportsProgress
                is set to true. */
            //bgWorker.ProgressChanged += bgWorker_ProgressChanged;

            //tell the backgroundWorker to raise the "DoWork" event, thus starting it.
            //Check to make sure the background worker is not already running.
            //if (!bgWorker.IsBusy) bgWorker.RunWorkerAsync();
        }

        public BackgroundWorker getBackgroundWorkerInstance()
        {
            // The first call will create the one and only instance.
            if (bgWorker == null)
                bgWorker = new BackgroundWorker();
            // Every call afterwards will return the single instance created above.
            return bgWorker;
        }


    }

}
