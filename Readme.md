Binding a private property so Entity Framework can track it
======================

This is a pretty simple project (mostly auto scaffolded) that shows how to setup a private property in a model to be saved to your database using Entity Framework.
The details of why it was created are on my blog at http://astutelogic.com/entity-framework-model-binding-private-properties

The only thing to take from this is the way to bind private properties.

The particular solution for having an encrypted value in the database but unencrypted in the model, as well as the "Encryption" algorithm, shown in this solution are NOT advised for production. This is demoware only.
