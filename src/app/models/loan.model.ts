export interface Loan {
    id: number;
    memberId: number;
    bookId: number;
    loanDate: string;
    dueDate: string;
    returnDate?: string;
    status: string;
  }
  