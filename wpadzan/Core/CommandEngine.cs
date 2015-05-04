using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace wpadzan.Core
{
    public class CommandEngine : ICommandEngine
    {
        private TimeSpan timespan = new TimeSpan(0, 0, 0, 0, 50);
        private int NumberOfCommandsRunned = 0;
        private int LimitNumberOfCommandsRunned = 50;
        private int NumberOfConcurrentRunning = 2;

        private List<ICommandItem> commandQueue;
        private List<ICommandItem> activeCommand;

        private System.Windows.Threading.DispatcherTimer timer
            = new System.Windows.Threading.DispatcherTimer();

        public CommandEngine()
        {
            this.commandQueue = new List<ICommandItem>();
            this.activeCommand = new List<ICommandItem>();

            timer.Interval = timespan;
            timer.Tick += timer_Tick;
        }

        public void Start()
        {
            try
            {
                timer.Start();
            }
            catch (Exception ex)
            {
            }
        }

        public void Stop()
        {
            try
            {
                timer.Stop();
            }
            catch (Exception ex)
            {
            }
        }

        protected virtual void timer_Tick(object sender, EventArgs e)
        {
#if DEBUG
            Logger.Delimiter();
            //Utility.Logger.Log("Tick");
            //Utility.MemoryHelper.MemoryDebug("Tick");
#endif

            // there are not command to perform, then ignore
            if (this.commandQueue.Count == 0)
            {
#if DEBUG
                Logger.Log("- Exit > No Command");
#endif
                return;
            }

            lock (activeCommand)
            {
                // clear the unused item first
                for (int i = 0; i < activeCommand.Count; i++)
                {
                    if (activeCommand[i].Status == CommandStatus.Finished)
                    {
                        ICommandItem temp = activeCommand[i];
                        activeCommand.RemoveAt(i);
                        i--;

                        // dispose the command item
#if DEBUG
                        Logger.Log("- Finished > " + temp.ToString());
#endif
                        temp.Dispose();
                    }
                }
            }

            // if number of activecommand is the same or larger with number of concurrent running then ignore
            if (this.activeCommand.Count >= this.NumberOfConcurrentRunning)
            {
#if DEBUG
                Logger.Log("- Exit > Concurrent Running is full : " + this.activeCommand.Count + " of " + this.NumberOfConcurrentRunning);
#endif
                return;
            }

            ICommandItem item;

            // lock command queue and then remove the front most command and put it on active queue
            lock (commandQueue)
            {
                item = commandQueue[0];
                commandQueue.RemoveAt(0);
            }

            // lock active command and then query each active command, if its already finished then remove from active command
            lock (activeCommand)
            {
                // finally add the new item
#if DEBUG
                Logger.Log("- Activate > " + item.ToString());
                Logger.Log("- Queue Vs Active > " + commandQueue.Count + " : " + activeCommand.Count);
#endif
                activeCommand.Add(item);
                item.PerformAsync();
                this.NumberOfCommandsRunned += 1;
            }

            if (NumberOfCommandsRunned > LimitNumberOfCommandsRunned)
            {
                NumberOfCommandsRunned = 0;
                GC.Collect();
            }
        }

        public virtual void Add(ICommandItem item)
        {
            // Command Type Queue Implementation is for later
            if (commandQueue.Count == 0)
                commandQueue.Add(item);
            else
                commandQueue.Add(item);
        }

        public void CancelAll()
        {
            timer.Stop();
            lock (activeCommand)
            {
                foreach (var command in activeCommand)
                {
                    command.Cancel();
                }
                activeCommand.Clear();
            }
            lock (commandQueue)
            {
                commandQueue.Clear();
            }
            timer.Start();
        }
    }
}
