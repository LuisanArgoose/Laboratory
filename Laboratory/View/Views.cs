using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory.View
{
    public class Views
    {
        private SingUp _singUp;
        public void OpenSingUp()
        {
            _singUp = new SingUp();
            _singUp.Show();
        }
        public void CloseSingUp()
        {
            _singUp.Close();
        }
        public void SetSingUp(SingUp singUp)
        {
            if(_singUp == null) 
                _singUp = singUp;
        }
        
    }
}
