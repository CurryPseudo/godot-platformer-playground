use gdnative::prelude::*;

#[derive(NativeClass)]
#[inherit(Node)]
pub struct Player;

#[methods]
impl Player {
    fn new(_owner: &Node) -> Self {
        Player
    }

    #[export]
    fn _ready(&self, _owner: &Node) {
        godot_print!("Hello, world.");
    }
}

fn init(handle: InitHandle) {
    handle.add_class::<Player>();
}

godot_init!(init);
