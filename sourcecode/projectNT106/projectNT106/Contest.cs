using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectNT106
{
    internal class Contest
    {
        public string Creator;
        public string RoomID = "";
        public string[] ParticipantList;

        public Contest(string IDCreator)
        {
            Creator = IDCreator;

            // Random RoomID
            Random rnd = new Random();
            int[] numRandoms = new int[4];
            for (int i = 0; i < 4; i++)
            {
                numRandoms[i] = rnd.Next(97, 122);
                RoomID += Convert.ToString(numRandoms[i]);
            }
        }

    }
}
