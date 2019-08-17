using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VoterInfoRepoPattern.Models;
using VoterInfoRepoPattern.Services;

namespace VoterInfoRepoPattern.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public IVoterInfoRepo _repo;
        public ValuesController(IVoterInfoRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAllVotersInfo()
        {
            var result = _repo.GetAllVotersInfo();
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddVoterInfo(VoterInfo data)
        {
            _repo.AddVoterInfo(data);
            return Ok();
        }
        [HttpGet("{VoterId}")]
        public IActionResult GetVoterInfoByVoterId(int VoterId)
        {
            VoterInfo result=_repo.GetVoterByVoterId(VoterId);
            return Ok(result);
        }
        [HttpPost]
        public IActionResult UpdateVoterInfo(VoterInfo data)
        {
            _repo.UpdateVoterInfo(data);
            return Ok();
        }
    }
}
