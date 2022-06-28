using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8ExampleInterface
{
    internal class GiometricVectorAtom : GiometricVector, IMoveAtom
    {
        public GiometricVectorAtom(int startPoint = 0, int endPoint = 0) : base(startPoint, endPoint)
        {
        }

        public void MoveAtom()
        {
            this.startPoint++;
            this.endPoint++;
        }
    }

    internal class GiometricVectorMoveDerive : GiometricVector, IMoveDerive
    {
        public GiometricVectorMoveDerive(int startPoint = 0, int endPoint = 0) : base(startPoint, endPoint)
        {
        }

        public void Move(int d)
        {
            this.startPoint += d;
            this.endPoint += d;
        }

        public void MoveAtom()
        {
            this.startPoint++;
            this.endPoint++;
        }
    }

    internal class GiometricVectorMove : GiometricVector, IMove
    {
        public GiometricVectorMove(int startPoint = 0, int endPoint = 0) : base(startPoint, endPoint)
        {
        }

        public void Move(int d)
        {
            this.startPoint += d;
            this.endPoint += d;
        }
    }

    internal class GiometricVectorTurn : GiometricVector, ITurn
    {
        public GiometricVectorTurn(int startPoint = 0, int endPoint = 0) : base(startPoint, endPoint)
        {
        }

        public void MoveAtom()
        {
            this.startPoint++;
            this.endPoint++;
        }

        public void Turn()
        {
            this.endPoint *= -1;
        }
    }

    internal class GiometricVectorComplex : GiometricVector, IComplexMove
    {
        public GiometricVectorComplex(int startPoint = 0, int endPoint = 0) : base(startPoint, endPoint)
        {
        }

        public void MoveAtom()
        {
            this.startPoint++;
            this.endPoint++;
        }

        public void Turn()
        {
            this.endPoint *= -1;
        }

    }

}
