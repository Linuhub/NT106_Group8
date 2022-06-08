using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projectNT106
{
    public class InforUser
    {
        private string IDUser;
        private string IDRoom;
        private string avatar;
        private int mark;
        private int rank;
        private double[] result = new double[21];
        public InforUser(string idRoom, string idUser)
        {
            IDRoom = idRoom;
            IDUser = idUser;
            avatar = "";
            mark = 0;
            rank = 0;
        }
        public string getIDRoom()
        {
            return IDRoom;
        }
        public string getIDUser()
        {
            return IDUser;
        }
        public double getResult(int index)
        {
            return result[index];
        }
        public string getMark()
        {
            return mark.ToString();
        }
        public void receiveUserAnswer(int indexQuestion, double time)
        {
            result[indexQuestion] = time;
            
        }
        public void calculateMark()
        {
            for (int i = 1; i <= 5; i++)
            {
                if (result[i] > 0)
                {
                    mark += 100 - (int)(result[i] / 10 * 100);

                }
            }
        }
        public void setAvatar(string path)
        {
            avatar = path;
        }
        public void setRank(int topX)
        {
            rank = topX;
        }
        public int getRank()
        {
            return rank;
        }
    }
}
