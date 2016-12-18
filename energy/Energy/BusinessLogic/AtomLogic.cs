using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class AtomLogic
    {
        public List<Atom> Atoms { get; private set; }
        public List<Atom> CalAtoms { get; private set; }

        public AtomLogic()
        {
            Atoms = new List<Atom>();
            CalAtoms = new List<Atom>();
        }

        public void InitAtoms()
        {
            var atom = new Atom() { PositionX = 12, PositionY = 39, Rv = 1, v = new Direction() { x = 3, y = 1 } };
            Atoms.Add(atom);
            CalAtoms.Add(atom);
        }

        public void CalAtom(int maxX, int maxY)
        {
            for (var i = 0; i < Atoms.Count; i++)
            {
                var calAtom = CalAtoms[i];
                

                var atom = Atoms[i];

            }
        }

    }
}
