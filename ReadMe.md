# Simple Word Processor

##Assumptions:
* Output format mentioned in the problem is not strict.
* I have taken liberty to consider composition length 6, given in problem as variable.
	
##Design and Considerations:
* SimpleWordProcessor.Core project contains the abstractions.
* SimpleWordProcessor.Lib project contains the implementation.
* SimpleWordProcessor.Client project contains the console client.	
* I have used Visitor Patten to keep the logic to traverse the words common to both the problems.
* Any problems which requires simple traversal of the words can be implemented by implementing IWordProcessor for the problem.
* Unit tests are indicative only and not exhaustive.
	
	