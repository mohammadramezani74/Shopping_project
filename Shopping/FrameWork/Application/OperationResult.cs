using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameWork.Application
{
    public class OperationResult
    {
        public string Message { get; set; }
        public bool IsSucceded { get; set; }
        public OperationResult()
        {
            IsSucceded = false;
        }
        public OperationResult succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSucceded = true;
            Message = message;
            return this;
        }
        public OperationResult Failed(string message)
        {
            IsSucceded = false;
            Message = message;
            return this;
        }
    }
}
