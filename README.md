# TaskApp


## Overview

This is an ASP.NET Core Web API application for managing tasks and users. The application uses a database named `TaskContext` to store information about users and tasks.

## Prerequisites

- .NET Core SDK
- SQL Server (or other supported database)

## Getting Started

1. Clone the repository:

   ```bash
   
# API Endpoints

Users
GET /api/users
Retrieves a list of all users.
GET /api/users/{id}
Retrieves details of a specific user.
POST /api/users
Creates a new user.
PUT /api/users/{id}
Updates details of a specific user.
DELETE /api/users/{id}
Deletes a specific user.
Tasks
GET /api/tasks
Retrieves a list of all tasks.
GET /api/tasks/{id}
Retrieves details of a specific task.
POST /api/tasks
Creates a new task.
PUT /api/tasks/{id}
Updates details of a specific task.
DELETE /api/tasks/{id}
Deletes a specific task.
GET /api/tasks/expired
Retrieves all expired tasks.
GET /api/tasks/active
Retrieves all active tasks.
GET /api/tasks/fromDate
Retrieves all tasks from a certain date.






