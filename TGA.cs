﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rubik
{
    public delegate void ProgressHandler(TChromosome best);
    public delegate double EvaluateHandler(TChromosome speciman);

    public class TGA <T> where T : TChromosome, new()
    {
        public static int PopulationCount = 100;
        public static double WinnerRatio = 0.3;
        public static double MutationRatio = 0.01;
        public static int GenerationsCount = 2000;
        public List<T> Population = new List<T>();
        
        public EvaluateHandler Evaluate;
        public ProgressHandler Progress;

        public enum TSelectionType {Rank, Tournament, Roulette, RouletteRank};
        public TSelectionType SelectionType;
        public T Best;

        public void Execute()
        {
            for (var i = 0; i < PopulationCount; i++)
            {
                var chromosome = new T();
                Population.Add(chromosome);
            }

            Best = Population[0];

            

            for (var j = 0; j < GenerationsCount; j++)
            {
                foreach(var speciman in Population)
                {
                    speciman.UnFitness = Evaluate(speciman);
                }

                Population.Sort((x, y) => x.UnFitness.CompareTo(y.UnFitness));
                if (Best.UnFitness > Population[0].UnFitness)
                    Best = Population[0];

                if (Progress != null)
                {
                    Progress(Population[0]);
                }

                var winnerCount = (int)(WinnerRatio * PopulationCount);
                List<T> winners = null;
                switch(SelectionType)
                {
                    case TSelectionType.Rank:
                        winners = SelectionRank(winnerCount);
                        break;
                    case TSelectionType.Tournament:
                        winners = SelectionRank(winnerCount);
                        break;

                }

                Population = new List<T>();
                for (int i = 0; i< PopulationCount/2; i++)
                {
                    var splitIdx = TChromosome.Rnd.Next(TChromosome.GenesLength);
                    var mom = winners[TChromosome.Rnd.Next(winnerCount)];
                    var dad = winners[TChromosome.Rnd.Next(winnerCount)];
                    var child = (T)mom.Cross(dad, splitIdx);
                    Population.Add(child);
                    child = (T)dad.Cross(mom, splitIdx);
                    Population.Add(child);
                }
                var mutationsCount = (int)(MutationRatio * PopulationCount);

                for(int i = 0; i< mutationsCount; i++)
                {
                    var mutant = Population[TChromosome.Rnd.Next(PopulationCount)];
                    mutant.Mutation(TChromosome.Rnd.Next(TChromosome.GenesLength));
                }
            }
        }

        private List<T> SelectionRank(int winnerCount)
        {
            return Population.GetRange(0, winnerCount);
        }
    }
}
