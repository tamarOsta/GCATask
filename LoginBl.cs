using loginApi.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loginApi.Bl
{
    public class LoginBl
    {
        string pass = "";
        string user = "";
        sqlFunc con = new sqlFunc();
        
        public bool InsertLoginDtl(string userName, string password)
        {

            string passEnc = SecurityHelper.EncodeToBase64(password);
            string userEnc = SecurityHelper.EncodeToBase64(userName);
            if (con.InsertLoginDtl(userEnc, passEnc))
                return true;
            return false;


        }

        public bool CheckLoginDtl(string userName, string password)
        {

            string userEnc = SecurityHelper.EncodeToBase64(userName);
            con.GetLoginData(userEnc, ref user, ref pass);


            if (user.Equals(userName))
            {
                if (pass.Equals(password))
                    return true;
                return false;

            }
            return false;


        }

    }
}