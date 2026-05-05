Markdown 

# SmartLogistics: Concurrent Warehouse Simulation

## Overview
SmartLogistics is a multi-threaded C# console application that simulates the operations of an automated warehouse. The project practically demonstrates the classic **Producer-Consumer problem**, utilizing concurrent threads (simulating robots) to handle the deposit and retrieval of packages of various sizes: Small, Medium, and Large.

## Core Concepts Demonstrated
* **Multithreading:** Independent worker threads act as automated robots, operating asynchronously.
* **Thread Synchronization:** Implements C# `Monitor` (`lock`, `Monitor.Wait()`, and `Monitor.PulseAll()`) to safely manage access to the shared critical section (the warehouse loading bay).
* **Deadlock & Starvation Prevention:** Safely coordinates multiple consumers and producers competing for a single shared resource without locking up the system.
* **Clean Code Architecture:** Utilizes the C# `partial class` feature to split the logic into multiple, highly readable files without complicating the shared state.

## Project Structure
The code is modular and organized into sequentially named files for easy navigation and readability:

* `1_main.cs`: Contains the application entry point, shared capacities, and the core Monitor lock.
* `2_piccoli.cs`: Producer and Consumer logic for Small packages (fast processing, high capacity).
* `3_medi.cs`: Producer and Consumer logic for Medium packages.
* `4_grandi.cs`: Producer and Consumer logic for Large packages (slow processing, low capacity).

## How to Run
To run this simulation on your local machine, ensure you have the [.NET SDK](https://dotnet.microsoft.com/download) installed.

1. Clone this repository to your local machine.
2. Open a terminal or command prompt inside the project folder.
3. Build and execute the project using the following command:
   bash
   dotnet run

*Copyright © 2026 knxzzq' and Domenico Maresca. All Rights Reserved.*
