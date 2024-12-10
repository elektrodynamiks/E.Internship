# Ruby 3.3.6
#

input = <<~EXAMPLE
47|53
97|13
97|61
97|47
75|29
61|13
75|53
29|13
97|29
53|29
61|53
97|53
61|29
47|13
75|47
97|75
47|61
75|61
47|29
75|13
53|13

75,47,61,53,29
97,61,53,29,13
75,29,13
75,97,47,61,53
61,13,29
97,13,75,29,47
EXAMPLE

class ReportsToProgression
  attr_reader :page_ordering_rules, :pages_to_produce 

  def initialize(input)
    @page_ordering_rules = []
    @pages_to_produce = []
    data_manipulation(input)
    main()
  end

  def data_manipulation(input)
    
  end

  def main()
    
  end
end