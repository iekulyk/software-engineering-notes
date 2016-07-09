MVC
---

Consider this pattern when developing software with a humancomputer
interface

The Model-View-ControUer architectural pattern (MVC) divides an
interactive application into three components. The model contains
the core functionality and data. Views display information to the user.
Controllers handle user input. Views and controllers together
comprise the user interface. A change-propagatlon mechanism
ensures consistency between the user interface and the model.


- The model component encapsulates core data and functionality.
The model is independent of specific output representations or
input behavior.

- View components display information to the user. A view obtains
the data it displays from the model. There can be multiple views of
the model.

- Each view has an associated controIler component. Controllers
receive input, usually as events that denote mouse movement, activation
of mouse buttons or keyboard input. Events are translated
to service requests, which are sent either to the model or to the
view. The user interacts with the system solely via controllers.

