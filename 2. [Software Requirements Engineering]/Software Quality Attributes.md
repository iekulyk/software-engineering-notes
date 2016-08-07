Software Quality Attributes
---

Several dozen product characteristics can be called quality attributes (Charette 1990), although most projects need to carefully consider only a handful of them. If developers know which of these characteristics are most crucial to project success, they can select architecture, design, and programming approaches to achieve the specified quality goals 

One way to classify attributes distinguishes those characteristics that are discernible at run time from those that aren't (Bass, Clements, and Kazman 1998). Another approach is to separate the visible characteristics that are primarily important to the users from under-the-hood qualities that are primarily significant to technical staff. The latter indirectly contribute to customer satisfaction by making the product easier to change, correct, verify, and migrate to new platforms.

Table 12-1 lists several quality attributes in both categories that every project should consider. Some attributes are critical to embedded systems (efficiency and reliability), whereas others might be especially pertinent to Internet and mainframe applications (availability, integrity, and maintainability) or to desktop systems (interoperability and usability). Embedded systems often have additional significant quality attributes, including safety (which was discussed in Chapter 10), installability, and serviceability. Scalability is another attribute that's important to Internet applications

  - Important Primarily to Users
    - Availability
    - Efficiency
    - Flexibility
    - Integrity
    - Interoperability
    - Reliability
    - Robustness
    - Usability
    
  - Important Primarily to Developers
    - Maintainability
    - Portability
    - Reusability
    - Testability
    
In an ideal universe, every system would exhibit the maximum possible value for all its attributes. The system would be available at all times, would never fail, would supply instantaneous results that are always correct, and would be intuitively obvious to use. Because nirvana is unattainable, you have to learn which attributes from Table 12-1 are most important to your project's success. Then define the user and developer goals in terms of these essential attributes so that designers can make appropriate choices. 

Different parts of the product need different combinations of quality attributes. Efficiency might be critical for certain components, while usability is paramount for others. Differentiate quality characteristics that apply to the entire product from those that are specific to certain components, certain user classes, or particular usage situations. Document any global quality goals in section 5.4 of the SRS template presented in Chapter 10, and associate specific goals with individual features, use cases, or functional requirements.

