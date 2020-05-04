using System;
using System.Collections.Generic;
using System.Text;

namespace DownloadManager
{
    public class DownloadManager
    {
        private List<DownloadJob> _jobs;

        public DownloadManager()
        {
            _jobs = new List<DownloadJob>();
        }

        public void Start()
        {
            _jobs.ForEach(j => j.Start());
        }

        public void Pause()
        {
            _jobs.ForEach(j => j.Strop());
        }

        public void Schedule()
        {
            
        }
    }
}
