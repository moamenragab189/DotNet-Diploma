using LibraryManagementSystem.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.oop.Builders
{
    internal class MemberManagerBuilder
    {
      private readonly MemberManager _MemberManager=new MemberManager();
        public MemberManagerBuilder setmember(Member member)
        {
            _MemberManager.member=member;
            return this;
        }
        public MemberManagerBuilder setdaysLate(int days)
        {
            _MemberManager.daysLate=days;
            return this;
        }
        public MemberManager Build()
        {
            return _MemberManager;
        }
    }
}
