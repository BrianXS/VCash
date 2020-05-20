using System;
using System.Collections.Generic;
using API.Enums;
using API.Enums.ATM;
using AutoMapper;

namespace API.Entities
{
    public class ATMMovement
    {
        public int Id { get; set; }
        
        public Currency Currency { get; set; }
        public DateTime DispatchDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string TrackingCode { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
        public List<ATMMovementDrawers> Drawerses { get; set; }
    }
}