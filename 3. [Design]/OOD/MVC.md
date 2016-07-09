MVC
---

Consider this pattern when developing software with a humancomputer
interface

Model–view–controller (MVC) is a software architectural pattern for implementing user interfaces on computers. It divides a given software application into three interconnected parts, so as to separate internal representations of information from the ways that information is presented to or accepted from the user.

- The model directly manages the data, logic and rules of the application.
- A view can be any output representation of information, such as a chart or a diagram. Multiple views of the same information are possible, such as a bar chart for management and a tabular view for accountants.
- The third part, the controller, accepts input and converts it to commands for the model or view.

---

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

