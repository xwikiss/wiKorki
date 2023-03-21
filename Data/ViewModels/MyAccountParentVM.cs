using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wiKorki.Data.ViewModels
{
    public class MyAccountParentVM
    {
        public ChangeCredentialsVM Credentials { get; set; }
        public ChangePasswordVM Password { get; set; }
    }
}
