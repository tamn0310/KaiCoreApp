CREATE PROC GetRevenueDaily
    @fromDate VARCHAR(10),
	@toDate VARCHAR(10)
AS
BEGIN

    select
        CAST(b.CreatedDate AS DATE) as Date,
		sum(bd.Quantity* bd.Price) as Revenue,
		sum((bd.Quantity* bd.Price)-(bd.Quantity* p.OriginalPrice)) as Profit
          from Bills b

        inner join dbo.BillDetails bd

        on b.Id = bd.BillId
        inner join Products p
        on bd.ProductId = p.Id

        where b.CreatedDate <= cast(@toDate as date)

        AND b.CreatedDate >= cast(@fromDate as date)

        group by b.CreatedDate
END

EXEC dbo.GetRevenueDaily @fromDate = '12/01/2019',
                        @toDate = '01/11/2020'