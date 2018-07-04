using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OrganizedEndeavors.Data;

namespace OrganizedEndeavors
{
    public class EndeavorsHub: Hub
    {
        public void NewEndeavor(string endeavor)
        {
            var endeavorRepo = new EndeavorsRepository1(Properties.Settings.Default.ConStr);
            endeavorRepo.AddEndeavor(endeavor);
            GetAndSendEndeavors1();
        }

        private void GetAndSendEndeavors1()
        {
            var endeavorRepo = new EndeavorsRepository1(Properties.Settings.Default.ConStr);
            var endeavors = endeavorRepo.GetIncompleteEndeavors();
            Clients.All.renderEndeavors(endeavors.Select(e => new
            {
                Id = e.Id,
                Endeavor1 = e.Endeavor1,
                HandledBy = e.HandledBy,
                MemberDoingIt = e.Member != null ? e.Member.Name : null,
            }));
        }

        public void GetAndSendEndeavors()
        {
            GetAndSendEndeavors1();
        }

        public void SetDoing(int endeavorId)
        {
            var memberRepo = new MembersRepository(Properties.Settings.Default.ConStr);
            var member = memberRepo.GetByEmail(Context.User.Identity.Name);
            var endeavorRepo = new EndeavorsRepository1(Properties.Settings.Default.ConStr);
            endeavorRepo.SetDoing(endeavorId, member.Id);
            GetAndSendEndeavors1();
        }

        public void SetDone(int endeavorId)
        {
            var endeavorRepo = new EndeavorsRepository1(Properties.Settings.Default.ConStr);
            endeavorRepo.SetCompleted(endeavorId);
            GetAndSendEndeavors1();
        }
    }
}