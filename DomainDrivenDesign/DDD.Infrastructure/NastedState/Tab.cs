//using AggregatRoot.Infrastructure.DiscriminatedUnion;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace AggregatRoot.NastedState
//{

//    public interface ICreatedTab
//    {
//        IOpendTab<MenuUnion> Opend();
//    }
//    public interface IOpendTab<TMenu>
//    {
//        IClosedTab Closed();
//        TMenu Menu();
//    }
//    public interface IClosedTab
//    {
//    }


//    public class Tab : ICreatedTab
//    {
//        IOpendTab<MenuUnion> Opend()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public class OpendTab<TMenu> : IOpendTab<TMenu>
//    {
//        public OpendTab(TMenu menu)
//        {

//        }
//        public IClosedTab Closed()
//        {
//            throw new NotImplementedException();
//        }

//        public TMenu Menu()
//        {
//            throw new NotImplementedException();
//        }
//    }

//    public interface IMenu { ISelectedMenu Selected();  }
//    public interface ISelectedMenu
//    {
//        OpendTab<ISelectedMenu> UpToRoot();
//    }
//    public class MenuUnion : Union<IMenu, ISelectedMenu>
//    {
//        public MenuUnion(IMenu t1) : base(t1)
//        {
//        }

//        public MenuUnion(ISelectedMenu t2) : base(t2)
//        {
//        }
//    }

//    public class SelectedMenu : ISelectedMenu
//    {
//        public OpendTab<ISelectedMenu> UpToRoot()
//        {
//            return new OpendTab<ISelectedMenu>(this);
//        }
//    }

//    public class ClosedTab : IClosedTab
//    {

//    }

//    public class TabUnion<TMenu> : Union<ICreatedTab, IOpendTab<TMenu>, IClosedTab>
//    {
//        public TabUnion(IOpendTab<TMenu> t2) : base(t2)
//        {
//        }

//        public TabUnion(IClosedTab t3) : base(t3)
//        {
//        }

//        public TabUnion(ICreatedTab t1) : base(t1)
//        {
//        }
//    }

//    class MyClass
//    {
//        public MyClass()
//        {

//            new TabUnion<ISelectedMenu>(
//                new Tab()
//            )
//            .Match(
//                s1 => s1.Opend(),
//                s2 => throw new Exception(),
//                s3 => throw new Exception()
//            )
//            .Menu()
//            .Match
//            (
//                s1 => s1.Selected(),
//                s2 => throw new Exception()
//            )
//            .UpToRoot()
//            .Closed();

//            //new Tab()
//            //    .Opend()
//            //    .Menu()
//            //    .Selected()
//            //    .Up()
//            //    .Closed()
//        }
//    }
//}
