Characteristics of Excellent Requirements
---

How can you distinguish good requirements specifications from those with problems? Several characteristics that individual requirement statements should exhibit are discussed in this section, followed by desirable characteristics of the SRS as a whole .
The best way to tell whether your requirements have these desired attributes is to have several project stakeholders carefully review the SRS. Different stakeholders will spot different kinds of problems. For example, analysts and developers can't accurately judge completeness or correctness, whereas users can't assess technical feasibility

###Requirement Statement Characteristics

In an ideal world, every individual user, business, and functional requirement would exhibit the qualities described in the following sections.

---

####Complete

Each requirement must fully describe the functionality to be delivered. It must contain all the information necessary for the developer to design and implement that bit of functionality. If you know you're lacking certain information, use TBD (to be determined) as a standard flag to highlight these gaps. Resolve all TBDs in each portion of the requirements before you proceed with construction of that portion.

---

####Correct

It must be possible to implement each requirement within the known capabilities and limitations of the system and its operating environment. To avoid specifying unattainable requirements, have a developer work with marketing or the requirements analyst throughout the elicitation process. The developer can provide a reality check on what can and cannot be done technically and what can be done only at excessive cost. Incremental development approaches and proof-of-concept prototypes are ways to evaluate requirement feasibility.

---

####Necessary

Each requirement should document a capability that the customers really need or one that's required for conformance to an external system requirement or a standard. Every requirement should originate from a source that has the authority to specify requirements. Trace each requirement back to specific voice-of-the-customer input, such as a use case, a business rule, or some other origin.

---

####Prioritized

Assign an implementation priority to each functional requirement, feature, or use case to indicate how essential it is to a particular product release. If all the requirements are considered equally important, it's hard for the project manager to respond to budget cuts, schedule overruns, personnel losses, or new requirements added during development.

---

####Unambiguous

All readers of a requirement statement should arrive at a single, consistent interpretation of it, but natural language is highly prone to ambiguity. Write requirements in simple, concise, straightforward language appropriate to the user domain. "Comprehensible" is a requirement quality goal related to "unambiguous": readers must be able to understand what each requirement is saying. Define all specialized terms and terms that might confuse readers in a glossary.

---

####Verifiable

See whether you can devise a few tests or use other verification approaches, such as inspection or demonstration, to determine whether the product properly implements each requirement. If a requirement isn't verifiable, determining whether it was correctly implemented becomes a matter of opinion, not objective analysis. Requirements that are incomplete, inconsistent, infeasible, or ambiguous are also unverifiable

---

###Requirements Specification Characteristics

It's not enough to have excellent individual requirement statements. Sets of requirements that are collected into a specification ought to exhibit the characteristics described in the following sections.

---

####Complete

No requirements or necessary information should be absent. Missing requirements are hard to spot because they aren't there!  Focusing on user tasks, rather than on system functions, can help you to prevent incompleteness.

---

####Consistent

Consistent requirements don't conflict with other requirements of the same type or with higher-level business, system, or user requirements. Disagreements between requirements must be resolved before development can proceed. You might not know which single requirement (if any) is correct until you do some research. Recording the originator of each requirement lets you know who to talk to if you discover conflicts.

---

####Modifiable

You must be able to revise the SRS when necessary and to maintain a history of changes made to each requirement. This dictates that each requirement be uniquely labeled and expressed separately from other requirements so that you can refer to it unambiguously. Each requirement should appear only once in the SRS. It's easy to generate inconsistencies by changing only one instance of a duplicated requirement. Consider cross-referencing subsequent instances back to the original statement instead of duplicating the requirement. A table of contents and an index will make the SRS easier to modify. Storing requirements in a database or a commercial requirements management tool makes them into reusable objects.

---

####Traceable

A traceable requirement can be linked backward to its origin and forward to the design elements and source code that implement it and to the test cases that verify the implementation as correct. Traceable requirements are uniquely labeled with persistent identifiers. They are written in a structured, fine-grained way as opposed to crafting long narrative paragraphs. Avoid lumping multiple requirements together into a single statement; the different requirements might trace to different design and code elements.

---
