using MembershipSystem.Middleware.Entities;
using MembershipSystem.Middleware.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace MembershipSystem.Utilities
{
    public class PayloadParser
    {
        public bool CheckRegistrationPayload(RegisterEmployeeRequest message)
        {
            if (message == null)
                return false;

            if (message.EmployeeId == null || message.EmployeeName == null || message.EmployeeEmail == null || message.EmployeeMobileNumber == null || message.Pin == null || message.CardId == null)
                return false;

            return true;
        }

//        //        //public bool CheckTopUpPayload(TopUpCard message)
//        //        //{
//        //        //    if (message == null)
//        //        //        return false;

//        //        //    if (message.Pin == null || message.CardId == null)
//        //        //        return false;

//        //        //    return true;
//        //        //}

//        //        //public bool CheckSpendPayload(SpendOnCard message)
//        //        //{
//        //        //    if (message == null)
//        //        //        return false;

//        //        //    if (message.Pin == null || message.CardId == null)
//        //        //        return false;

//        //        //    return true;
//        //        //}
//        //    }

}
}
