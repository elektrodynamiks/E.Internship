# Ruby 3.3.6
#
input = <<~EXAMPLE
7 6 4 2 1
1 2 7 8 9
9 7 6 2 1
1 3 2 4 5
8 6 4 4 1
1 3 6 7 9
EXAMPLE

class ReportsToProgression
  attr_reader :reports, :number_of_safe_reports

  def initialize(input, tolerate_bad_level)
    @reports = []
    @number_of_safe_reports = 0
    data_manipulation(input)
    main(tolerate_bad_level)
  end

  def data_manipulation(input)
    input.each_line do |line|
      @reports << line.scan(/\w+/).map(&:to_i)
    end
  end

  def main(tolerate_bad_level)
    @reports.each do |report|
      # print report
      # puts safety_report_check?(report)
      if safety_report_check?(report) then
        safety_reports_count()
      else
        # generate the reports_with_tolerance
        reports_with_tolerance(report) if tolerate_bad_level
      end
      # puts "#--"
    end
    print "How many reports are safe: ",  @number_of_safe_reports
    puts
  end

  # PART I
  def report_to_progression(levels)
    progression = []
    levels.each_with_index.map do |level, index|
      progression << (levels[index] - levels[index - 1]) if (index > 0)
    end
    return progression
  end

  def safety_report_check?(report)
    progression = report_to_progression(report)
    # progression is increasing or decreasing
    increasing = progression.all? { |level| level > 0 }
    decreasing = progression.all? { |level| level < 0 }
    if (increasing ^ decreasing)
      # progression differ > 1 and <= 3
      at_least_one = progression.none? { |element| element.abs() == 0 }
      at_most_three = progression.none? { |element| element.abs() > 3 }
      return (at_least_one & at_most_three)
    end
    return (increasing ^ decreasing)
  end
  
  def safety_reports_count()
    @number_of_safe_reports += 1
  end

  # PART II
def  reports_with_tolerance(report)
  # puts
  for i in 0..report.length()-1 do
    input = report.clone
    input.delete_at(i)
    # check on the sub-reports as created, we need only one safe.
    if safety_report_check?(input) then
      # print input,"safe"
      # puts
      safety_reports_count()
    break
    end
  end
    
  end
end


# Part I
# set tolerate_bad_level = true for PART II
tolerate_bad_level = false

puts "example"
check_the_reports = ReportsToProgression.new(input, tolerate_bad_level)
# check for the puzzle
puts "puzzle"
puzzle_input = File.read("day02_input.txt")
check_the_reports = ReportsToProgression.new(puzzle_input, tolerate_bad_level)
