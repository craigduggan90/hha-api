# HHA Recruitment Test Project - Full Stack or Backend Developers

This document details a mini-project that we would like you, as a candidate for a development role at HHA, to implement.
The intent is to allow us to gain an understanding of your approach to implementations, and of your technical capabilities.

## Implementation Stack

You may chose any implementation stack for this task that you feel will best present your skills and abilities, and that you feel most confident in to allow you to successfully achieve the task.
That said, please do also give consideration to the role you are applying for, and consider if your choice will demonstrate a good match to that role.  
For example, whilst you are quite free to implement this in, say, COBOL, consider if that will actually tell us anything meaningful about your abilities with, say, FORTRAN  (languages mentioned are, clearly, not likely to be the ones actually under consideration)

## What we expect to receive (task output)

We would like you to provide the following:

* Full, buildable, source code for the implementation
* Any required build and project files
* README style instructions on how to build **and run** the application
* details of approximately how much time you spent

You should share this with us as a GitHub repository.

You do NOT need to provide instructions for installing the underlying language or runtime, though you may specify a specific version as a pre-requisite.
For example, if working in Java, you do not need to provide instructions on installing Java, but you may wish, in the README, to specify a pre-requisite of, say
  
  "Java 21 must be installed/available"

### Follow up questions

Should you be invited for further interview, you should be prepared to discuss your work.  This may include questions about;

* the choices you made and why you made them
* what resources you used and why
* what you feel could be improved given more time
* what you think is good
* where the requirements might be expanded if this were a real project, with more time available, and so on.

## Time for task

We estimate that this task should take around 2 - 4 hours.   Please bear in mind that this time means that we do not expect fully polished, production ready code, but you should be prepared to expand upon anything you have chosen not to include for reasons of brevity.

## Due Date

You will be given a due date for completion when this task is supplied to you.  In all but the most pressing of circumstances, this will be at least 1 week away, but if, for any reason (such as booked holidays, existing work commitments etc) you feel you will need longer, you should raise this as soon as possible with your recruitment contact.

## Allowed resources

You may use any and all resources that you feel appropriate to the task, including IDEs, web resources, AI assistants and the like, and of course such software libraries as you deem appropriate.  

You *must* however produce the source code yourself, and outright plagiarism (copying someone elses work, or getting someone else to write it for you) is NOT allowed, and will, if seen, disqualify you from proceeding any further.

## The Task requirements

We would like you to build the following:

A standalone application that;

* shall provide a single webservice on the url path **'redact'** that;
  * when POST is used, accepts arbitrary text in the request body and returns the received text with any word that is in a defined, configurable list, changed to 'REDACTED' in the response body.
  * when GET is used identifies itself as 'Redaction Service' by returning a single String 'Redaction Service' in the response body
* It should be possible to define the list of words for redaction by configuration
* All calls to POST on the web service shall be written to a log *file*, with a timestamp, and the text from the request prior to redaction
* The port the service presents on *should be configurable at runtime*, that is you should be able to start the application to run on a defined port
  * you do not need to be able to change the port whilst the application is running.

For the avoidance of doubt, the webservice should be available on the following URL

    http://localhost:[port]/redact

### The list of words to be changed to REDACTED

The list of words subject to redaction for testing purposes will be:

* Dog
* Cat
* Snake
* Dolphin
* Mammal

For example, the text

  A dog, a monkey or a dolphin are all mammals. A snake, however, is not a mammal, it is a reptile. Who can say what a DogSnake is?

should be returned as

  A REDACTED, a monkey or a REDACTED are all mammals. A REDACTED, however, is not a REDACTED, it is a reptile. Who can say what a DogSnake is?

### Additional elements

We require only the features listed above, and, as mentioned, do not expect 'production ready' code.  However, if you feel you have time, you may add further features that you believe would be useful for such a webservice, or even just if they demonstrate something interesting.

### System Tests

We have also provided you with a Postman (https://www.postman.com/) collection that can be used to verify the functionality of the endpoint.
We expect, at a minimum, that the requests in this collection should be successful (or, where testing an error case, the correct error code is received), but you do not need to restrict yourself to these tests if you feel you can usefully apply other test methods or approaches in the time allowed. 

#  Questions?

If you wish to ask **any** questions about this task, then please get them to the contact indicated when you received this project.  Please do not be afraid to ask questions, in fact we encourage this, as that will give you best chance of successfully completing the task.  A good approach when considering the questions you might ask is to treat this as if it a requirements document received from a customer, and you need to clarify certain points in order to be able to successfully deliver the product.  That said questions about the test itself, and the overall process, are also welcomed.


