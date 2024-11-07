-> main

=== main ===
What day do you like the most?
    + [Monday]
        -> chosen("Monday")
    + [Holiday]
        -> chosen("Holiday")
    + [Birthday]
        -> chosen("Birthday")

===chosen(day)===
You like {day}!
-> END