using MyDrawing.shape;
using System;

namespace MyDrawing.command
{
    public class DeleteCommand : ICommand
    {
        Model model;
        Shape[] shape;
        int[] indexes;
        public DeleteCommand(Model model, int[] indexes)
        {
            this.model = model;
            Array.Sort(indexes);
            this.indexes = indexes;
        }

        public void Execute()
        {
            shape = new Shape[indexes.Length];
            for (int i = indexes.Length - 1; i >= 0; i--)
            {
                shape[i] = model.GetShapes()[indexes[i]];
                this.model.RemoveShapeAt(indexes[i]);
            }
        }

        public void UnExecute()
        {
            for (int i = 0; i < indexes.Length; i++)
            {
                this.model.InsertShape(indexes[i], shape[i]);
            }
        }
    }
}
