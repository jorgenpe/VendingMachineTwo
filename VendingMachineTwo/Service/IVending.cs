using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Model;

namespace VendingMachine.Service
{
    public interface IVending
    {
        Product Purchase(int id);
        List<string> ShowAll();
        string Details(int id);
        int InsertMoney(int money);
        Dictionary<int, int> EndTransaction();
        void Clear();
    }
}
