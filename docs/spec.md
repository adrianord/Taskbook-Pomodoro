# Specification and design

!!! Everything in this document is subject to change !!!

## Concepts

### Task

A task is the smallest unit in TaskBook Pomodoro. A task contains the following fields.

- ID (sequential)
- Creation date
- unique guid
- description
- priority
- series of tags
- reference to a pomodoro
- due date

### Pomodoro

A pomodoro is a series of reoccurring time allocated to the task to work on.

### Tags
Tags are used to link different tasks together. Tags can take on two forms, Value tags or Key Value tags.

Value tags are your bog standard tag like many other platforms.

Key Value tags are used to give tags a name property to search on. Key Value tags also add their values as value tags.
Keys can be repeated multiple times to add multiple values to the same key.

A task with the following tags:
```
- taskbook
- pomodoro
- project=taskbook-pomodoro
- technology=csharp
- technology=dotnet
```
Will have the tags
```
- taskbook
- pomodoro
- taskbook-pomodoro
- csharp
- dotnet
```
Where querying project will return `taskbook-promodo`

and querying technology will return `csharp` and `dotnet`.

Certain Key Value tags in Taskbook Pomodoro are used in the UI to help quickly identify tasks. The current supported
Key Value tags are:

- project - Used to assign a project to the given task
- section - Used to apply a section under a given project. Must be used under project. Sub section can be created by
  using `/` as a divider. Ex. `section=backend/feature/one`



## Components

### CLI

### TUI

### API Server

### Web Application

### Neovim Plugin

### Database

## Settings

### Top Level
| Name | Description          | Type         | Default |
| ---- | -------------------- | ------------ | ------- |
| db   | The backing database | [DB](DB)     | {}      |
| pomo | pomodoro behaviour   | [Pomo](Pomo) | {}      |

### DB

| Name             | Description                                       | Type                   | Default |
| ---------------- | ------------------------------------------------- | ---------------------- | ------- |
| provider         | The backing database provider                     | ["sqlite", "postgres"] | sqlite  |
| connectionString | Database Connection String. Not needed for sqlite | string                 | null    |
| deletionStrategy | How to delete tasks                               | ["soft", "hard"]       | soft    |

### Pomo

| Name         | Description                                                             | Type    | Default |
| ------------ | ----------------------------------------------------------------------- | ------- | ------- |
| auto         | Whether to automatically create a pomo per task                         | boolean | true    |
| defaultCount | Default number of pomodoros to create                                   | number  | 4       |
| defaultTime  | Default time each pomodoro takes. (s = seconds, m = minutes, h = hours) | string  | 20m     |
