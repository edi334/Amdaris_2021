using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace F1Management.Core.Models.Car
{
    public class RaceCar
    {
        public RaceCar(string id, string teamId, Chassis chassis, Engine engine, Gearbox gearbox, List<Tire> tires)
        {
            Id = id;
            MakeRaceCar(teamId, chassis, engine, gearbox, tires);
        }
        public void MakeRaceCar(string teamId, Chassis chassis, Engine engine, Gearbox gearbox, List<Tire> tires)
        {
            if (teamId == null)
            {
                throw new NullReferenceException("No team assigned to car");
            }
            if (chassis == null)
            {
                throw new NullReferenceException("Chassis is null");
            }
            if (engine == null)
            {
                throw new NullReferenceException("Engine is null");
            }
            if (gearbox == null)
            {
                throw new NullReferenceException("Gearbox is null");
            }
            if (tires.Count > 4)
            {
                throw new Exception("Car cannot have more than 4 tires.");
            }
            tires.ForEach(t =>
            {
                if (t.Type != tires[0].Type)
                {
                    throw new Exception("A car must have all tires of the same type");
                }
            });
            tires.ForEach(t =>
            {
                if (t == null)
                {
                    throw new NullReferenceException("One of the tires is null");
                }
            });

            TeamId = teamId;
            Chassis = chassis;
            Engine = engine;
            Gearbox = gearbox;
            Tires = tires;
        }
        public string Id { get; set; }
        public string TeamId { get; set; }
        public Chassis Chassis { get; set; }
        public Engine Engine { get; set; }
        public Gearbox Gearbox { get; set; }
        public List<Tire> Tires { get; set; }
        public double TotalWear => (Chassis.Wear + Engine.Wear + Gearbox.Wear) / 3;
    }
}
