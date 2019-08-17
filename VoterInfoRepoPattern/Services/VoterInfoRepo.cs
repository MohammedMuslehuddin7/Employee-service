using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VoterInfoRepoPattern.Models;

namespace VoterInfoRepoPattern.Services
{
    public class VoterInfoRepo:IVoterInfoRepo
    {
        private ToDoTaskContext _context;
        public VoterInfoRepo(ToDoTaskContext context)
        {
            _context = context;
        }
        public int AddtwoNumber(int a, int b)
        {
            return a + b;
        }
        public List<VoterInfo> GetAllVotersInfo()
        {
            var result = _context.VoterInfo.ToList();
            return result;
        }
        public void UpdateVoterInfo(VoterInfo data)
        {
            _context.VoterInfo.Update(data);
            _context.SaveChanges();
        }
        public void AddVoterInfo(VoterInfo data)
        {
            _context.VoterInfo.Add(data);
            _context.SaveChanges();
        }
        public VoterInfo GetVoterByVoterId(int VoterId)
        {
            var result = _context.VoterInfo.FirstOrDefault(x => x.VoterId == VoterId);
            return result;
        }
    }
    public interface IVoterInfoRepo
    {
        int AddtwoNumber(int a, int b);
        List<VoterInfo> GetAllVotersInfo();
        void AddVoterInfo(VoterInfo data);
        void UpdateVoterInfo(VoterInfo data);
        VoterInfo GetVoterByVoterId(int VoterId);

    } 
}
