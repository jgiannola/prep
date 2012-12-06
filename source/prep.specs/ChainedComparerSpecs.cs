using System;
using System.Security;
using System.Security.Principal;
using System.Threading;
using Machine.Specifications;
using Rhino.Mocks;
using developwithpassion.specifications.rhinomocks;
using prep.collections;
using developwithpassion.specifications.extensions;
using System.Data;
using prep.utility.sorting;
using System.Collections.Generic;

namespace prep.specs
{
  public class ChainedComparerSpecs
  {
    public abstract class concern : Observes<IComparer<int>, ChainedComparer<int>>
    {
    }
      
    public class when_comparing_a_smaller_number_and_a_larger_number : concern
    {
      Establish c = () =>
      {
        //var comparer = fake.an<IComparer<int>>;
        //var comparer = 1;
        var firstComparer = depends.on<IComparer<int>>();
        firstComparer.setup(x => x.Compare(2,3)).Return(-1);
        var secondComparer = depends.on<IComparer<int>>();
        secondComparer.setup(x => x.Compare(3,2)).Return(1);
      };
      Because b = () =>
        result = sut.Compare(2, 3);

      It should_return_negative_one = () =>
        result.ShouldEqual(-1);

      static int result;
    }

    public class when_comparing_a_larger_number_and_a_smaller_number : concern
    {
        Establish c = () =>
        {
            //var comparer = fake.an<IComparer<int>>;
            //var comparer = 1;
            var firstComparer = depends.on<IComparer<int>>();
            firstComparer.setup(x => x.Compare(2, 3)).Return(-1);
            var secondComparer = depends.on<IComparer<int>>();
            secondComparer.setup(x => x.Compare(3, 2)).Return(1);
        };
        Because b = () =>
          result = sut.Compare(3, 2);

        It should_return_one = () =>
          result.ShouldEqual(1);

        static int result;
    }

    public class when_comparing_like_numbers : concern
    {
        Establish c = () =>
        {
            //var comparer = fake.an<IComparer<int>>;
            //var comparer = 1;
            var firstComparer = depends.on<IComparer<int>>();
            firstComparer.setup(x => x.Compare(2, 3)).Return(-1);
            var secondComparer = depends.on<IComparer<int>>();
            secondComparer.setup(x => x.Compare(3, 2)).Return(1);
        };
        Because b = () =>
          result = sut.Compare(3, 3);

        It should_return_zero = () =>
          result.ShouldEqual(0);

        static int result;
    }   
  
  }

}
