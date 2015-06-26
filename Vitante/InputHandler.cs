using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Vitante {
    class InputHandler {

        //Current and previous keyboard states and keybindings
        private KeyboardState KBCurrent, KBPrevious;
        private Dictionary<InputActions, Keys> KBBindings;

        //Current and previous gamepad states and keybindings
        private GamePadState GPCurrent, GPPrevious;
        private Dictionary<InputActions, Buttons> GPBindings;

        public delegate void InputEvent();

        //Define events
        public event InputEvent onMoveLeft = delegate { };
        public event InputEvent onMoveLeftRelease = delegate { };
        public event InputEvent onMoveRight = delegate { };
        public event InputEvent onMoveRightRelease = delegate { };
        public event InputEvent onJump = delegate { };
        public event InputEvent onJumpHold = delegate { };
        public event InputEvent onJumpRelease = delegate { };
        public event InputEvent onExit = delegate { };

        public InputHandler() {
            KBPrevious = Keyboard.GetState();
            GPPrevious = GamePad.GetState(PlayerIndex.One);
            ResetBindings();
        }

        private void PollKeyboard() {
            KBPrevious = KBCurrent;
            KBCurrent = Keyboard.GetState();

            foreach (KeyValuePair<InputActions, Keys> keyBinding in KBBindings) {

                // Was a Key Pressed?
                if (KBCurrent.IsKeyDown(keyBinding.Value) && KBPrevious.IsKeyUp(keyBinding.Value)) {
                    switch (keyBinding.Key) {
                        case InputActions.MovementLeft:
                            onMoveLeft();
                            break;

                        case InputActions.MovementRight:
                            onMoveRight();
                            break;

                        case InputActions.MovementJump:
                            onJump();
                            break;

                        case InputActions.ActionExit:
                            onExit();
                            break;
                    }
                }

                // Was a Key Held?
                else if (KBCurrent.IsKeyDown(keyBinding.Value) && KBPrevious.IsKeyDown(keyBinding.Value)) {
                    switch (keyBinding.Key) {
                        case InputActions.MovementJump:
                            onJumpHold();
                            break;
                    }
                }

                // Was a Key Released?
                else if (KBCurrent.IsKeyUp(keyBinding.Value) && KBPrevious.IsKeyDown(keyBinding.Value)) {
                    switch (keyBinding.Key) {
                        case InputActions.MovementLeft:
                            onMoveLeftRelease();
                            break;

                        case InputActions.MovementRight:
                            onMoveRightRelease();
                            break;

                        case InputActions.MovementJump:
                            onJumpRelease();
                            break;
                    }
                }
            }
        }

        private void PollGamePad() {
            GPPrevious = GPCurrent;
            GPCurrent = GamePad.GetState(PlayerIndex.One);
            // TODO: Add gampad code
        }

        //Update method to call in gameloop
        public void Update() {
            PollKeyboard();
            PollGamePad();
        }

        //Set default bindings
        //In the future, this may read from a config file
        public void ResetBindings() {
            KBBindings = new Dictionary<InputActions, Keys>() {
                { InputActions.MovementLeft, Keys.Left },
                { InputActions.MovementRight, Keys.Right },
                { InputActions.MovementJump, Keys.Space },
                { InputActions.ActionExit, Keys.Escape }
            };

            GPBindings = new Dictionary<InputActions, Buttons>() {
                { InputActions.MovementLeft, Buttons.DPadLeft },
                { InputActions.MovementRight, Buttons.DPadRight },
                { InputActions.MovementJump, Buttons.A },
                { InputActions.ActionExit, Buttons.Back }
            };
        }

        private void ChangeBinding(InputActions inputAction, Keys key) {
        }

        private void ChangeBinding(InputActions inputAction, Buttons button) {
        }

        // various enumerated actions
        // (future: maybe seperate input actions for each gamestate into seperate enums?)
        enum InputActions {
            MovementLeft,
            MovementRight,
            MovementJump,
            ActionExit
        }
    }
}
