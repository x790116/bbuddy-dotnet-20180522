@web
Feature: Budget
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

Scenario: Add a new Budget
		When add a Budget With month "2018-05" and amount 500
		Then the following Budget will be added
	| month   | amount |
	| 2018-05 | 500    |
