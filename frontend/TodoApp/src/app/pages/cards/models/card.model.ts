export class CardItem {
  Name: string;
  Description: string;
  CreatedAt: Date;
  Status: string;

  constructor(
    name: string,
    description: string,
    createdAt: Date,
    status: string
  )
  {
    this.Name = name;
    this.Description = description;
    this.CreatedAt = createdAt;
    this.Status = status
  }
}
