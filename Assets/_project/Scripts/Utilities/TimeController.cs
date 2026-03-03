using UnityEngine;

namespace Utilites
{
    public class TimeController
    {
        public void StopTime()
        {
            Time.timeScale = 0;
        }

        public void ResumeTime()
        {
            Time.timeScale = 1;
        }
    }
}