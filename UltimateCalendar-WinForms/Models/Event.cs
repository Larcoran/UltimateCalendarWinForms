﻿using System;

namespace UltimateCalendar_WinForms
{
    public class Event
    {
        public Event()
        {
            //intentionally empty;
        }

        public Event(int Id, string Description, int UserId,DateTime Date,DateTime Time,string Type)
        {
            this.Id = Id;
            this.Description = Description;
            this.UserId = UserId;
            this.Date = Date;
            this.Time = Time;
            this.Type = Type;
        }

        public override string ToString()
        {
            return $"An event with id:{Id} will occure at {Time.Hour}:{Time.Minute}. It is {Type}. {Description}.";
        }

        public int Id { get; set; }

        public string Description { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public DateTime Time { get; set; }

        public string Type { get; set; }
    }
}