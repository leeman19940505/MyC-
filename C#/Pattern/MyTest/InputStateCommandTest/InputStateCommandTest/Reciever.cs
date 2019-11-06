using System;

namespace InputStateCommandTest
{
    /// <summary>
    /// 接收者
    /// </summary>
    class Reciever
    { 
        public void Operation(Action aAction, Message aMessage)
        {
            switch(aAction)
            {
                case Action.Foreward:
                    Foreward(aAction, aMessage);
                    break;
                case Action.Backward:
                    Backward(aAction, aMessage);
                    break;
                default:
                    break;
            }
        }

        private void Backward(Action aAction, Message aMessage)
        {
            aMessage.Input.Text = aMessage.InputValue;
        }

        private void Foreward(Action aAction, Message aMessage)
        {
            aMessage.Input.Text = aMessage.InputValue;
        }
    }
}