
Object Json 1

{
  "stronk": {
    "id": "test0",
    "name": "data",
    "var": "123",
    "date": "2024-05-17T00:00:00",
    "obj": {"strik": 3, "enx": 1}
  },
  "name": "data",
  "arr": {
    "Objects": [],
    "Strings": [],
    "Ints": [1, 23, 4],
    "SampleObjects": [
      {"id": "111", "Name": "string1" },
      {"id": "333", "Name": "string22"}
    ]
  },
  "brr": [
    {"id": "testarr" , "value": "arres"},
    {"id": "testarr2", "value": "arres"}
  ],
  "obj": {"id": null, "Name": "name"}
}

Object Json 2

{
  "stronk": {
    "id": "test1",
    "name": "data",
    "var": "123",
    "date": "2024-05-17T14:11:55.6974058+07:00",
    "obj": {"strik": 1, "enx": 2}
  },
  "name": "data",
  "arr": {
    "Objects": ["2024-05-17T14:11:55.6987444+07:00", "nhac", 1, 244],
    "Strings": ["value", "test"],
    "Ints": [1, 23, 477],
    "SampleObjects": [
      {"id": "111", "Name": "bbb"},
      {"id": "222", "Name": "ccc"}
    ]
  },
  "brr": [
    {"id": "testarr" , "value": "arres"},
    {"id": "testarr2", "value": "arres"}
  ],
  "obj": {"id": null, "Name": "name"}
}



=>> After Merger 

{
  "stronk": {
    "id": "test0",
    "name": "data",
    "var": "123",
    "date": "2024-05-17T14:11:55.6974058+07:00",
    "obj": {"strik": 1, "enx": 2}
  },
  "name": "data",
  "arr": {
    "Objects": ["2024-05-17T14:11:55.6987444+07:00", "nhac", 1, 244],
    "Strings": ["value", "test"],
    "Ints": [1, 23, 477],
    "SampleObjects": [
      {"id": "111", "Name": "bbb"},
      {"id": "333", "Name": "ccc"}
    ]
  },
  "brr": [
    {"id": "testarr" , "value": "arres"},
    {"id": "testarr2", "value": "arres"}
  ],
  "obj": {"id": null, "Name": "name"}
}

