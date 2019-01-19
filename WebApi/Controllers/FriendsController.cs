using Business.Friends;
using Business.HistoricoLog;
using Microsoft.AspNetCore.Mvc;
using Model.Friends;
using Model.HistoricoLog;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApi.Attributes;

namespace WebApi.Controllers
{
    [BasicAuthorize()]
    [Route("api/[controller]")]
    public class FriendsController : Controller
    {
        private readonly IBFriend _bFriends;
        private readonly IBCalculoHistoricoLog _bCalculoHistoricoLog;

        public FriendsController(IBFriend bFriends, IBCalculoHistoricoLog bCalculoHistoricoLog)
        {
            _bFriends = bFriends;
            _bCalculoHistoricoLog = bCalculoHistoricoLog;
        }

        [HttpGet]
        [Route("GetAllFriends")]
        public IActionResult GetAllFriends()
        {
            return Ok(_bFriends.GetListAll(x => true));
        }

        [HttpPost]
        [Route("CalculateNextFriends")]
        public IActionResult CalculateNextFriends(string name)
        {
            Friend me = _bFriends.GetListAll(x => x.Name == name).FirstOrDefault();

            List<Friend> Friends = _bFriends.GetListAll(x => x.Name != name).ToList();

            foreach (var item in Friends)
            {
                item.Distance = Math.Sqrt(Math.Abs((me.Latitude - item.Latitude * me.Latitude - item.Latitude)) + Math.Abs((me.Longitude - item.Longitude * me.Longitude - item.Longitude)));

                _bCalculoHistoricoLog.Add(new CalculoHistoricoLog() { Log = "Math.Sqrt(Math.Abs((" + me.Latitude + " - " + item.Latitude + " * " + me.Latitude + " - " + item.Latitude + ")) + Math.Abs((" + me.Longitude + " - " + item.Longitude + " * " + me.Longitude + " - " + item.Longitude + ")))" });
            }

            if (Friends.Count() > 3)
                return Ok(Friends.OrderBy(x => x.Distance).Take(3));
            else
                return Ok(Friends);
        }
    }
}