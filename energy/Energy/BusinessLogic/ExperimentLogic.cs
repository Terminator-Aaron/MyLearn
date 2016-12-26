using Db.Models;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class ExperimentLogic
    {
        public EnergyContext DbContext { get; private set; }

        public Experiment Experiment { get; private set; }

        public ExperimentLogic()
        {
            DbContext = new EnergyContext();
        }

        public bool CreateExperiment(Experiment experiment, List<EnergyCellExtend> cellExtends, List<AtomExtend> atomExtends,
            out List<EnergyCellExtend> newCells, out List<AtomExtend> newAtoms)
        {
            List<Tuple<EnergyCellExtend, EnergyCell>> cellPairs = new List<Tuple<EnergyCellExtend, EnergyCell>>();

            List<EnergyCell> energyCells = new List<EnergyCell>();
            cellExtends.ForEach(m =>
            {
                var energyCell = new EnergyCell();
                energyCell.CellX = m.CellX;
                energyCell.CellY = m.CellY;
                energyCell.Order = m.Order;
                m.Experiment = experiment;
                energyCells.Add(energyCell);

                cellPairs.Add(new Tuple<EnergyCellExtend, EnergyCell>(m, energyCell));
            });



            List<Tuple<AtomExtend, Atom>> atomPairs = new List<Tuple<AtomExtend, Atom>>();

            List<Atom> atoms = new List<Atom>();
            atomExtends.ForEach(m =>
            {
                var atom = new Atom();
                atom.VolumeRadius = m.VolumeRadius;
                atom.AttractionRadius = m.AttractionRadius;
                atom.AttractionForce = m.AttractionForce;
                atom.Order = m.Order;
                atom.Experiment = experiment;
                atoms.Add(atom);

                atomPairs.Add(new Tuple<AtomExtend, Atom>(m, atom));
            });



            experiment.StartCells = energyCells.Count;
            experiment.StartHotPots = cellExtends.Count(m => m.IsHotPot);
            experiment.StartAtoms = atoms.Count;

            experiment.EnergyCells = energyCells;
            experiment.Atoms = atoms;

            DbContext.Experiments.Add(experiment);
            DbContext.SaveChanges();

            Experiment = experiment;

            cellPairs.ForEach(m =>
            {
                m.Item1.EnergyCellID = m.Item2.EnergyCellID;
                m.Item1.ExperimentID = m.Item2.ExperimentID;
            });
            newCells = cellPairs.Select(m => m.Item1).ToList();


            atomPairs.ForEach(m =>
            {
                m.Item1.AtomID = m.Item2.AtomID;
                m.Item1.ExperimentID = m.Item2.ExperimentID;
            });
            newAtoms = atomPairs.Select(m => m.Item1).ToList();

            return true;
        }

        public void SaveExperimentTickData(List<EnergyCellTick> tickCells, List<AtomTick> tickAtoms)
        {
            DbContext = new EnergyContext();

            //List<Atom> atoms = new List<Atom>();
            //newAtoms.ForEach(m =>
            //{

            //    var atom = new Atom();
            //    atom.AtomID = m.AtomID;
            //    atom.VolumeRadius = m.VolumeRadius;
            //    atom.AttractionRadius = m.AttractionRadius;
            //    atom.AttractionForce = m.AttractionForce;
            //    atom.ExperimentID = this.Experiment.ExperimentID;

            //    atoms.Add(atom);
            //});

            //List<EnergyCell> energyCells = new List<EnergyCell>();
            //newCells.ForEach(m =>
            //{
            //    var energyCell = new EnergyCell();
            //    energyCell.EnergyCellID = m.EnergyCellID;
            //    energyCell.CellX = m.CellX;
            //    energyCell.CellY = m.CellY;
            //    energyCell.ExperimentID = this.Experiment.ExperimentID;
            //    energyCells.Add(energyCell);
            //});

            DbContext.EnergyCellTicks.AddRange(tickCells);
            DbContext.AtomTicks.AddRange(tickAtoms);
            DbContext.SaveChanges();
        }
    }
}
