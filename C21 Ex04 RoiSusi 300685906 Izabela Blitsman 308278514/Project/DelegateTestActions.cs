namespace Ex04.Menus.Test
{
    class DelegateTestActions

    {
        private readonly ActionsCollection r_ActionsCollection = new ActionsCollection();

        public void ActionsCollection_ShowDate()
        {
            r_ActionsCollection.ShowDate();
        }

        public void ActionsCollection_ShowTime()
        {
            r_ActionsCollection.ShowTime();
        }

        public void ActionsCollection_CountSpaces()
        {
            r_ActionsCollection.CountSpaces();
        }

        public void ActionsCollection_ShowVerison()
        {
            r_ActionsCollection.ShowVerison();
        }
    }

}
