using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.Builders
{
    internal class LoanServiceBuilder
    {
        private readonly LoanService _loanService =new LoanService();

        public LoanServiceBuilder setbookid(string id)
        {
            _loanService.bookId = id;
            return this;
        }
        public LoanServiceBuilder setmemberid(string id)
        {
            _loanService.memberId = id;
            return this;
        }
        public LoanService Build() 
        {
            return _loanService;
        }

    }
}
