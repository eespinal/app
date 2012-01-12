namespace app.tasks.startup
{
    public class CombinedStep : IRunAStartupStep 
    {
        readonly IRunAStartupStep first_step;
        readonly IRunAStartupStep second_step;

        public CombinedStep(IRunAStartupStep first_step,IRunAStartupStep second_step)
        {
            this.first_step = first_step;
            this.second_step = second_step;
        }

        public void run()
        {
            first_step.run();
            second_step.run();
        }
    }
}