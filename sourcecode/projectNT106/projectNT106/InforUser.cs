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
        private int avatar;
        private int mark;
        private int rank;
        private double[] result = new double[21];
        public InforUser(string idRoom, string idUser)
        {
            IDRoom = idRoom;
            IDUser = idUser;
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
        public int getMark()
        {
            return mark;
        }
        public void receiveUserAnswer(int indexQuestion, double time)
        {
            result[indexQuestion] = time;
            
        }
        public void calculateMark()
        {
            for (int i = 1; i <= 20; i++)
            {
                if (result[i] > 0)
                {
                    mark += 1000 - (int)(result[i] / 20 * 1000);

                }
            }
        }
        public void setAvatar(int avt)
        {
            avatar = avt;
        }
        public void setRank(int topX)
        {
            rank = topX;
        }
        public int getRank()
        {
            return rank;
        }
        public int getAvt()
        {
            return avatar;
        }
    }
}
