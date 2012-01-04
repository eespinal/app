configs ={
  :git => {
    :user => "20120109intellisys",
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
