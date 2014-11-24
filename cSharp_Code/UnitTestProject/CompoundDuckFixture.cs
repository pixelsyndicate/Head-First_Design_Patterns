using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HeadFirstDesignPatterns.Compound.Duck;

namespace UnitTestProject
{
    [TestClass]
    public class CompoundDuckFixture
    {
        #region Members
		AbstractDuckFactory duckFactory;
		IQuackable mallardDuck;
		IQuackable redheadDuck;
		IQuackable duckCall;
		IQuackable rubberDuck ;
		IQuackable gooseDuck;
		Flock flockOfDucks;
		Flock flockOfMallards;
		IQuackable mallardOne;
		IQuackable mallardTwo;
		IQuackable mallardThree;
		IQuackable mallardFour;
		Quackologist quackologist;
		#endregion//Members

		#region SetUp
		[TestInitialize]
		public void Init()
		{
			duckFactory = new CountingDuckFactory();

			//QuackCounter is Decorator Pattern
			mallardDuck = duckFactory.CreateMallardDuck();
			redheadDuck = duckFactory.CreateRedheadDuck();
			duckCall = duckFactory.CreateDuckCall();
			rubberDuck = duckFactory.CreateRubberDuck();
			gooseDuck = new GooseAdapter(new Goose());//Adapter Pattern

			//Flock is Iterator Pattern
			flockOfDucks = new Flock();
			
			flockOfDucks.Add(redheadDuck);
			flockOfDucks.Add(duckCall);
			flockOfDucks.Add(rubberDuck);
			flockOfDucks.Add(gooseDuck);

			flockOfMallards = new Flock();
			
			mallardOne = duckFactory.CreateMallardDuck();
			mallardTwo = duckFactory.CreateMallardDuck();
			mallardThree = duckFactory.CreateMallardDuck();
			mallardFour = duckFactory.CreateMallardDuck();
            
			flockOfMallards.Add(mallardOne);
			flockOfMallards.Add(mallardTwo);
			flockOfMallards.Add(mallardThree);
			flockOfMallards.Add(mallardFour);

			flockOfDucks.Add(flockOfMallards);
		}
		#endregion//SetUp

		#region TearDown
		[TestCleanup]
		public void Dispose()
		{
			duckFactory = null;
			mallardDuck = null;
			redheadDuck = null;
			duckCall = null;
			rubberDuck = null;
			gooseDuck = null;
			flockOfDucks = null;
			flockOfMallards = null;
			mallardOne = null;
			mallardTwo = null;
			mallardThree = null;
			mallardFour = null; 
		}
		#endregion//TearDown

		#region DuckSimulator
		[TestMethod]
		public void DuckSimulator()
		{
			QuackCounter.QuackCount = 0;//set to zero just in case 

			Console.WriteLine("Duck Simulator: With Abstract Factory");
			Console.WriteLine("Duck Simulator: Whole Flock Simulation");
			Console.WriteLine(Simulate(flockOfDucks));
			Console.WriteLine("Duck Simulator: Mallard Flock Simulation");
			Console.WriteLine(Simulate(flockOfMallards));

			Console.WriteLine("The ducks quacked " + QuackCounter.QuackCount + " times");
		}
		#endregion//DuckSimulator

		#region DuckSimulatorObserver
		[TestMethod]
		public void DuckSimulatorObserver()
		{
			QuackCounter.QuackCount = 0;//set to zero just in case 

			quackologist = new Quackologist();
			flockOfDucks.RegisterObserver(quackologist);

			Console.WriteLine("Duck Simulator: With Observer");
			Console.WriteLine(Simulate(flockOfDucks));

			Console.WriteLine("The ducks quacked " + QuackCounter.QuackCount + " times");
		}
		#endregion//DuckSimulatorObserver

		#region Simulate - Helper Method
		private string Simulate(IQuackable duck)
		{	
			return duck.Quack();
		}
		#endregion//Simulate - Helper Method
    }
}
