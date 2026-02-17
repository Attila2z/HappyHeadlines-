workspace "Happy Headlines" "C1 - System Context" {

  model {
    publisher = person "Publisher" "Writes drafts and publishes finished articles."
    reader    = person "Reader" "Reads articles, comments, subscribes, and shares."

    hh = softwareSystem "Happy Headlines" "Positive news website + newsletter platform."

    

    publisher -> hh "Drafts, reviews, publishes articles" "Web Browser (HTTPS)"
    reader    -> hh "Reads articles, comments, subscribes" "Web Browser (HTTPS)"

    
  }

  views {
    systemContext hh "C1" "System Context" {
      include publisher
      include reader
      include hh
      
      autolayout lr
    }

    styles {
      element "Person" {
        shape Person
        background #08427b
        color #ffffff
        stroke #052e5b
        strokeWidth 2
        fontSize 28
        metadata true
        description false
      }

      element "Software System" {
        shape RoundedBox
        background #1168bd
        color #ffffff
        stroke #0b4f8a
        strokeWidth 2
    
        fontSize 28
        metadata true
        description false
      }

      

      
    }
  }

  configuration {
    scope softwareSystem
  }
}
